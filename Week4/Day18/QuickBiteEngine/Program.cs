using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ============================================================
// 1. ENTITY INTERFACE
// ============================================================

public interface IEntity
{
    int Id { get; }
}


// ============================================================
// 2. ENUM
// ============================================================

public enum OrderStatus
{
    Placed,
    Queued,
    Dispatched,
    Delivered,
    Cancelled
}


// ============================================================
// 3. DOMAIN MODEL
// ============================================================

public class MenuItem : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public MenuItem(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} - ₹{Price}";
    }
}


public class Restaurant : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsOpen { get; set; }

    // Dictionary gives fast lookup by MenuItem ID
    public Dictionary<int, MenuItem> Menu { get; } =
        new Dictionary<int, MenuItem>();

    public Restaurant(int id, string name, bool isOpen)
    {
        Id = id;
        Name = name;
        IsOpen = isOpen;
    }

    public void AddMenuItem(MenuItem item)
    {
        Menu[item.Id] = item;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} | Open: {IsOpen} | Menu Items: {Menu.Count}";
    }
}


public class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVip { get; set; }

    public Customer(int id, string name, bool isVip)
    {
        Id = id;
        Name = name;
        IsVip = isVip;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} | VIP: {IsVip}";
    }
}


public class OrderItem
{
    public MenuItem MenuItem { get; set; }
    public int Quantity { get; set; }

    public OrderItem(MenuItem menuItem, int quantity)
    {
        MenuItem = menuItem;
        Quantity = quantity;
    }

    public decimal TotalPrice
    {
        get { return MenuItem.Price * Quantity; }
    }

    public override string ToString()
    {
        return $"{MenuItem.Name} x {Quantity}";
    }
}


public class Order : IEntity
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public Restaurant Restaurant { get; set; }

    public List<OrderItem> Items { get; } =
        new List<OrderItem>();

    public DateTime PlacedAt { get; set; }
    public bool IsExpress { get; set; }
    public OrderStatus Status { get; set; }

    public Order(
        int id,
        Customer customer,
        Restaurant restaurant,
        DateTime placedAt,
        bool isExpress)
    {
        Id = id;
        Customer = customer;
        Restaurant = restaurant;
        PlacedAt = placedAt;
        IsExpress = isExpress;
        Status = OrderStatus.Placed;
    }

    public void AddItem(MenuItem item, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        Items.Add(new OrderItem(item, quantity));
    }

    public decimal TotalAmount
    {
        get
        {
            return Items.Sum(item => item.TotalPrice);
        }
    }

    public override string ToString()
    {
        string type = IsExpress ? "Express" : "Normal";

        return $"Order #{Id} | Customer: {Customer.Name} | " +
               $"Restaurant: {Restaurant.Name} | {type} | " +
               $"Status: {Status} | Placed: {PlacedAt:HH:mm:ss}";
    }
}


// ============================================================
// 4. DELIVERY AGENT
// ============================================================

public class DeliveryAgent
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DeliveryAgent(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Id}: {Name}";
    }
}


// ============================================================
// 5. DISPATCH RECORD
// ============================================================

public class DispatchRecord
{
    public Order Order { get; }
    public DeliveryAgent Agent { get; }
    public DateTime DispatchedAt { get; }

    public DispatchRecord(
        Order order,
        DeliveryAgent agent,
        DateTime dispatchedAt)
    {
        Order = order;
        Agent = agent;
        DispatchedAt = dispatchedAt;
    }
}


// ============================================================
// 6. GENERIC REPOSITORY
// ============================================================

public class Repository<T> : IEnumerable<T>
    where T : class, IEntity
{
    private readonly Dictionary<int, T> entities =
        new Dictionary<int, T>();


    // Add
    public void Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        if (entities.ContainsKey(entity.Id))
            throw new InvalidOperationException(
                $"Entity with ID {entity.Id} already exists.");

        entities.Add(entity.Id, entity);
    }


    // Update
    public void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        if (!entities.ContainsKey(entity.Id))
            throw new KeyNotFoundException(
                $"Entity with ID {entity.Id} does not exist.");

        entities[entity.Id] = entity;
    }


    // Remove
    public bool Remove(int id)
    {
        return entities.Remove(id);
    }


    // GetById
    public T GetById(int id)
    {
        entities.TryGetValue(id, out T entity);
        return entity;
    }


    // GetAll
    public IEnumerable<T> GetAll()
    {
        return entities.Values;
    }


    // Count
    public int Count
    {
        get { return entities.Count; }
    }


    // IEnumerable<T>
    public IEnumerator<T> GetEnumerator()
    {
        return entities.Values.GetEnumerator();
    }


    // Non-generic IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


// ============================================================
// 7. ORDER PRIORITY COMPARER
// ============================================================

public class OrderPriorityComparer : IComparer<Order>
{
    public int Compare(Order x, Order y)
    {
        if (ReferenceEquals(x, y))
            return 0;

        if (x == null)
            return 1;

        if (y == null)
            return -1;


        // 1. Express orders first
        int expressComparison =
            y.IsExpress.CompareTo(x.IsExpress);

        if (expressComparison != 0)
            return expressComparison;


        // 2. VIP customers first
        int vipComparison =
            y.Customer.IsVip.CompareTo(x.Customer.IsVip);

        if (vipComparison != 0)
            return vipComparison;


        // 3. Earlier orders first
        int timeComparison =
            x.PlacedAt.CompareTo(y.PlacedAt);

        if (timeComparison != 0)
            return timeComparison;


        // Final tie-breaker
        return x.Id.CompareTo(y.Id);
    }
}


// ============================================================
// 8. DISPATCH QUEUE
// ============================================================

public class DispatchQueue
{
    // Priority queue:
    // Express/VIP orders
    private readonly Queue<Order> priorityQueue =
        new Queue<Order>();


    // Normal orders
    private readonly Queue<Order> normalQueue =
        new Queue<Order>();


    // Enqueue
    public void Enqueue(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));


        // Express OR VIP gets priority
        if (order.IsExpress || order.Customer.IsVip)
        {
            priorityQueue.Enqueue(order);
        }
        else
        {
            normalQueue.Enqueue(order);
        }

        order.Status = OrderStatus.Queued;
    }


    // DispatchNext
    public Order DispatchNext()
    {
        if (priorityQueue.Count > 0)
        {
            Order order = priorityQueue.Dequeue();

            order.Status = OrderStatus.Dispatched;

            return order;
        }


        if (normalQueue.Count > 0)
        {
            Order order = normalQueue.Dequeue();

            order.Status = OrderStatus.Dispatched;

            return order;
        }


        throw new InvalidOperationException(
            "No orders are waiting for dispatch.");
    }


    // Number of pending orders
    public int Count
    {
        get
        {
            return priorityQueue.Count + normalQueue.Count;
        }
    }


    // Check empty
    public bool IsEmpty
    {
        get { return Count == 0; }
    }


    // Full priority-order view
    public List<Order> GetPriorityView()
    {
        List<Order> allOrders =
            priorityQueue
                .Concat(normalQueue)
                .ToList();

        allOrders.Sort(new OrderPriorityComparer());

        return allOrders;
    }
}


// ============================================================
// 9. QUICKBITE DISPATCH ENGINE
// ============================================================

public class QuickBiteEngine
{
    // Repositories
    public Repository<Restaurant> Restaurants { get; }
    public Repository<Customer> Customers { get; }
    public Repository<Order> Orders { get; }


    // Dispatch queue
    private readonly DispatchQueue dispatchQueue;


    // Delivery-agent roster
    private readonly LinkedList<DeliveryAgent> agents;


    // Undo history
    private readonly Stack<DispatchRecord> dispatchHistory;


    // Maximum undo records
    private readonly int maxHistory;


    public QuickBiteEngine(int maxHistory = 10)
    {
        Restaurants = new Repository<Restaurant>();
        Customers = new Repository<Customer>();
        Orders = new Repository<Order>();

        dispatchQueue = new DispatchQueue();

        agents = new LinkedList<DeliveryAgent>();

        dispatchHistory =
            new Stack<DispatchRecord>();

        this.maxHistory = maxHistory;
    }


    // ========================================================
    // DELIVERY AGENTS
    // ========================================================

    public void AddDeliveryAgent(DeliveryAgent agent)
    {
        if (agent == null)
            throw new ArgumentNullException(nameof(agent));

        agents.AddLast(agent);
    }


    // Get first agent and rotate to back
    public DeliveryAgent GetNextAvailableAgent()
    {
        if (agents.Count == 0)
            throw new InvalidOperationException(
                "No delivery agents are available.");


        LinkedListNode<DeliveryAgent> first =
            agents.First;

        agents.RemoveFirst();

        agents.AddLast(first);

        return first.Value;
    }


    // ========================================================
    // ORDER OPERATIONS
    // ========================================================

    public void AddOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        Orders.Add(order);

        dispatchQueue.Enqueue(order);
    }


    public void QueueExistingOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        dispatchQueue.Enqueue(order);
    }


    // ========================================================
    // DISPATCH
    // ========================================================

    public DispatchRecord DispatchNext()
    {
        if (dispatchQueue.IsEmpty)
            throw new InvalidOperationException(
                "No orders available for dispatch.");


        Order order = dispatchQueue.DispatchNext();

        DeliveryAgent agent =
            GetNextAvailableAgent();


        DispatchRecord record =
            new DispatchRecord(
                order,
                agent,
                DateTime.Now);


        // Keep last N dispatches
        dispatchHistory.Push(record);

        if (dispatchHistory.Count > maxHistory)
        {
            RemoveOldestHistoryRecord();
        }


        Console.WriteLine(
            $"Dispatched Order #{order.Id} to {agent.Name}");

        return record;
    }


    // ========================================================
    // UNDO LAST DISPATCH
    // ========================================================

    public bool UndoLastDispatch()
    {
        if (dispatchHistory.Count == 0)
            return false;


        DispatchRecord record =
            dispatchHistory.Pop();


        // Revert order status
        record.Order.Status =
            OrderStatus.Queued;


        // Put agent back at the FRONT
        agents.AddFirst(record.Agent);


        // Put order back into queue
        dispatchQueue.Enqueue(record.Order);


        Console.WriteLine(
            $"Undo successful: Order #{record.Order.Id} " +
            $"returned to queue.");


        return true;
    }


    // ========================================================
    // REMOVE OLDEST HISTORY RECORD
    // ========================================================

    private void RemoveOldestHistoryRecord()
    {
        if (dispatchHistory.Count <= maxHistory)
            return;


        DispatchRecord[] records =
            dispatchHistory.ToArray();


        dispatchHistory.Clear();


        for (int i = records.Length - 2; i >= 0; i--)
        {
            dispatchHistory.Push(records[i]);
        }
    }


    // ========================================================
    // COMPLETE DELIVERY
    // ========================================================

    public void CompleteDelivery(
        Order order,
        DeliveryAgent agent)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        if (agent == null)
            throw new ArgumentNullException(nameof(agent));


        order.Status =
            OrderStatus.Delivered;


        Console.WriteLine(
            $"Order #{order.Id} delivered by {agent.Name}");
    }


    // ========================================================
    // REPORTING 1
    // TODAY'S UNIQUE CUSTOMERS
    // ========================================================

    public HashSet<int> TodaysUniqueCustomerIds()
    {
        DateTime today = DateTime.Today;


        HashSet<int> customerIds =
            new HashSet<int>();


        foreach (Order order in Orders)
        {
            if (order.PlacedAt.Date == today)
            {
                customerIds.Add(order.Customer.Id);
            }
        }


        return customerIds;
    }


    // ========================================================
    // REPORTING 2
    // LOW AVAILABILITY RESTAURANTS
    // ========================================================

    public Dictionary<int, int> LowAvailabilityRestaurants(
        int minMenuItems)
    {
        Dictionary<int, int> result =
            new Dictionary<int, int>();


        foreach (Restaurant restaurant in Restaurants)
        {
            int menuCount =
                restaurant.Menu.Count;


            if (menuCount < minMenuItems)
            {
                result[restaurant.Id] =
                    menuCount;
            }
        }


        return result;
    }


    // ========================================================
    // REPORTING 3
    // TOP ORDERED ITEMS
    // ========================================================

    public List<(string ItemName, int TotalOrdered)>
        TopOrderedItems(int topN)
    {
        if (topN <= 0)
            return new List<(string, int)>();


        // Item name -> total quantity
        Dictionary<string, int> itemCounts =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);


        foreach (Order order in Orders)
        {
            // Cancelled orders are not counted
            if (order.Status == OrderStatus.Cancelled)
                continue;


            foreach (OrderItem item in order.Items)
            {
                string name =
                    item.MenuItem.Name;


                if (itemCounts.ContainsKey(name))
                {
                    itemCounts[name] +=
                        item.Quantity;
                }
                else
                {
                    itemCounts[name] =
                        item.Quantity;
                }
            }
        }


        // Convert to list for ranking
        List<(string ItemName, int TotalOrdered)> result =
            itemCounts
                .Select(pair =>
                    (pair.Key, pair.Value))
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(topN)
                .ToList();


        return result;
    }


    // ========================================================
    // REPORTING 4
    // CUSTOMER ORDERED FROM BOTH RESTAURANTS
    // ========================================================

    public bool CustomerOrderedFromBothRestaurants(
        int customerId,
        int restaurantIdA,
        int restaurantIdB)
    {
        HashSet<int> restaurantHistory =
            new HashSet<int>();


        foreach (Order order in Orders)
        {
            if (order.Customer.Id == customerId)
            {
                restaurantHistory.Add(
                    order.Restaurant.Id);
            }
        }


        // HashSet membership checks
        return restaurantHistory.Contains(restaurantIdA)
            && restaurantHistory.Contains(restaurantIdB);
    }


    // ========================================================
    // PRIORITY VIEW
    // ========================================================

    public List<Order> GetPendingPriorityView()
    {
        return dispatchQueue.GetPriorityView();
    }


    // ========================================================
    // ROSTER VIEW
    // ========================================================

    public List<DeliveryAgent> GetAgentRoster()
    {
        return agents.ToList();
    }
}


// ============================================================
// 10. PROGRAM
// ============================================================

public class Program
{
    public static void Main()
    {
        QuickBiteEngine engine =
            new QuickBiteEngine(5);


        // ====================================================
        // CREATE MENU ITEMS
        // ====================================================

        MenuItem burger =
            new MenuItem(1, "Burger", 150);

        MenuItem pizza =
            new MenuItem(2, "Pizza", 300);

        MenuItem fries =
            new MenuItem(3, "Fries", 100);

        MenuItem pasta =
            new MenuItem(4, "Pasta", 220);

        MenuItem sandwich =
            new MenuItem(5, "Sandwich", 120);


        // ====================================================
        // CREATE RESTAURANTS
        // ====================================================

        Restaurant restaurant1 =
            new Restaurant(
                101,
                "Food Palace",
                true);

        restaurant1.AddMenuItem(burger);
        restaurant1.AddMenuItem(pizza);
        restaurant1.AddMenuItem(fries);


        Restaurant restaurant2 =
            new Restaurant(
                102,
                "Quick Meals",
                true);

        restaurant2.AddMenuItem(pasta);
        restaurant2.AddMenuItem(sandwich);


        Restaurant restaurant3 =
            new Restaurant(
                103,
                "Small Cafe",
                true);

        restaurant3.AddMenuItem(burger);


        engine.Restaurants.Add(restaurant1);
        engine.Restaurants.Add(restaurant2);
        engine.Restaurants.Add(restaurant3);


        // ====================================================
        // CREATE CUSTOMERS
        // ====================================================

        Customer arshil =
            new Customer(
                1,
                "Arshil",
                true);

        Customer rahul =
            new Customer(
                2,
                "Rahul",
                false);

        Customer aman =
            new Customer(
                3,
                "Aman",
                false);


        engine.Customers.Add(arshil);
        engine.Customers.Add(rahul);
        engine.Customers.Add(aman);


        // ====================================================
        // CREATE DELIVERY AGENTS
        // ====================================================

        DeliveryAgent agent1 =
            new DeliveryAgent(
                1,
                "Agent A");

        DeliveryAgent agent2 =
            new DeliveryAgent(
                2,
                "Agent B");

        DeliveryAgent agent3 =
            new DeliveryAgent(
                3,
                "Agent C");


        engine.AddDeliveryAgent(agent1);
        engine.AddDeliveryAgent(agent2);
        engine.AddDeliveryAgent(agent3);


        // ====================================================
        // CREATE ORDERS
        // ====================================================

        DateTime now = DateTime.Now;


        // VIP order
        Order order1 =
            new Order(
                1001,
                arshil,
                restaurant1,
                now.AddMinutes(-30),
                false);

        order1.AddItem(burger, 2);
        order1.AddItem(fries, 1);


        // Normal order
        Order order2 =
            new Order(
                1002,
                rahul,
                restaurant1,
                now.AddMinutes(-20),
                false);

        order2.AddItem(pizza, 1);


        // Express order
        Order order3 =
            new Order(
                1003,
                aman,
                restaurant2,
                now.AddMinutes(-15),
                true);

        order3.AddItem(pasta, 2);


        // Normal order
        Order order4 =
            new Order(
                1004,
                rahul,
                restaurant2,
                now.AddMinutes(-10),
                false);

        order4.AddItem(sandwich, 2);


        // Express + VIP
        Order order5 =
            new Order(
                1005,
                arshil,
                restaurant2,
                now.AddMinutes(-5),
                true);

        order5.AddItem(pasta, 1);
        order5.AddItem(sandwich, 1);


        // Another restaurant order
        Order order6 =
            new Order(
                1006,
                rahul,
                restaurant1,
                now.AddMinutes(-2),
                false);

        order6.AddItem(burger, 1);


        // ====================================================
        // ADD ORDERS
        // ====================================================

        engine.AddOrder(order1);
        engine.AddOrder(order2);
        engine.AddOrder(order3);
        engine.AddOrder(order4);
        engine.AddOrder(order5);
        engine.AddOrder(order6);


        // ====================================================
        // REPOSITORY TEST
        // ====================================================

        Console.WriteLine(
            "\n========== REPOSITORY ==========");

        foreach (Order order in engine.Orders)
        {
            Console.WriteLine(order);
        }


        // ====================================================
        // PRIORITY VIEW
        // ====================================================

        Console.WriteLine(
            "\n========== PRIORITY VIEW ==========");

        List<Order> priorityView =
            engine.GetPendingPriorityView();


        foreach (Order order in priorityView)
        {
            Console.WriteLine(order);
        }


        // ====================================================
        // DISPATCH
        // ====================================================

        Console.WriteLine(
            "\n========== DISPATCH ==========");

        DispatchRecord dispatch1 =
            engine.DispatchNext();

        DispatchRecord dispatch2 =
            engine.DispatchNext();

        DispatchRecord dispatch3 =
            engine.DispatchNext();


        // ====================================================
        // UNDO LAST DISPATCH
        // ====================================================

        Console.WriteLine(
            "\n========== UNDO ==========");

        engine.UndoLastDispatch();


        // ====================================================
        // DISPATCH AGAIN
        // ====================================================

        Console.WriteLine(
            "\n========== DISPATCH AFTER UNDO ==========");

        DispatchRecord dispatch4 =
            engine.DispatchNext();


        // ====================================================
        // DELIVERY
        // ====================================================

        Console.WriteLine(
            "\n========== DELIVERY ==========");

        engine.CompleteDelivery(
            dispatch1.Order,
            dispatch1.Agent);


        // ====================================================
        // UNIQUE CUSTOMERS
        // ====================================================

        Console.WriteLine(
            "\n========== TODAY'S UNIQUE CUSTOMERS ==========");

        HashSet<int> uniqueCustomers =
            engine.TodaysUniqueCustomerIds();


        foreach (int id in uniqueCustomers)
        {
            Console.WriteLine(
                $"Customer ID: {id}");
        }


        // ====================================================
        // LOW AVAILABILITY RESTAURANTS
        // ====================================================

        Console.WriteLine(
            "\n========== LOW AVAILABILITY RESTAURANTS ==========");

        Dictionary<int, int> lowRestaurants =
            engine.LowAvailabilityRestaurants(3);


        foreach (KeyValuePair<int, int> item
            in lowRestaurants)
        {
            Console.WriteLine(
                $"Restaurant ID: {item.Key}, " +
                $"Menu Items: {item.Value}");
        }


        // ====================================================
        // TOP ORDERED ITEMS
        // ====================================================

        Console.WriteLine(
            "\n========== TOP ORDERED ITEMS ==========");

        List<(string ItemName, int TotalOrdered)> topItems =
            engine.TopOrderedItems(3);


        foreach (var item in topItems)
        {
            Console.WriteLine(
                $"{item.ItemName}: {item.TotalOrdered}");
        }


        // ====================================================
        // BOTH RESTAURANTS
        // ====================================================

        Console.WriteLine(
            "\n========== CUSTOMER RESTAURANT HISTORY ==========");

        bool orderedFromBoth =
            engine.CustomerOrderedFromBothRestaurants(
                2,
                101,
                102);


        Console.WriteLine(
            $"Customer 2 ordered from Restaurant 101 " +
            $"and 102: {orderedFromBoth}");


        // ====================================================
        // DELIVERY AGENT ROSTER
        // ====================================================

        Console.WriteLine(
            "\n========== AGENT ROSTER ==========");

        foreach (DeliveryAgent agent
            in engine.GetAgentRoster())
        {
            Console.WriteLine(agent);
        }


        Console.WriteLine(
            "\n========== PROGRAM FINISHED ==========");
    }
}