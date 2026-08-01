public class Solution
{
    public static int truckTour(List<List<int>> petrolpumps)
    {
        int startingPump = 0;
        int currentPetrol = 0;
        int totalDeficit = 0;

        for (int i = 0; i < petrolpumps.Count; i++)
        {
            int petrolGiven = petrolpumps[i][0];
            int distanceToNext = petrolpumps[i][1];

            currentPetrol += petrolGiven - distanceToNext;

            // If the truck runs out of petrol before reaching the next pump
            if (currentPetrol < 0)
            {
                // Accumulate the deficit from this failed track segment
                totalDeficit += currentPetrol;
                // Move the start candidate to the next pump
                startingPump = i + 1;
                // Reset current petrol for the new tracking tour
                currentPetrol = 0;
            }
        }

        // If overall net fuel is sufficient to cover the total trip requirements
        return (currentPetrol + totalDeficit >= 0) ? startingPump : -1;
    }
}
