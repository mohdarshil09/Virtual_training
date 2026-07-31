namespace Healthcare_ICU_PatientMonitoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Patient[] records = new Patient[5];

            records[0].HeartRate = 75;
            records[0].OxygenLevel = 98;
            records[0].SystolicBP = 120;
            records[0].DiastolicBP = 80;
            records[0].Time = "10:14";

            records[1].HeartRate = 110;
            records[1].OxygenLevel = 95;
            records[1].SystolicBP = 130;
            records[1].DiastolicBP = 85;
            records[1].Time = "10:48";

            records[2].HeartRate = 55;
            records[2].OxygenLevel = 89;
            records[2].SystolicBP = 100;
            records[2].DiastolicBP = 70;
            records[2].Time = "11:32";

            records[3].HeartRate = 80;
            records[3].OxygenLevel = 97;
            records[3].SystolicBP = 118;
            records[3].DiastolicBP = 78;
            records[3].Time = "12:03";

            records[4].HeartRate = 125;
            records[4].OxygenLevel = 92;
            records[4].SystolicBP = 140;
            records[4].DiastolicBP = 90;
            records[4].Time = "12:56";

          //  Console.WriteLine("ICU Patient Monitoring Report :\n");

            for (int i = 0; i < records.Length; i++)
            {
                int patientNumber = i + 1;
                Console.WriteLine("ICU Patient " + patientNumber + " Monitoring Report :");

                Console.WriteLine("Time: " + records[i].Time);
                Console.WriteLine("Heart Rate: " + records[i].HeartRate);
                Console.WriteLine("Oxygen Level: " + records[i].OxygenLevel);
                Console.WriteLine("Blood Pressure: " + records[i].SystolicBP + "/" + records[i].DiastolicBP);



                // Abnormal Check 
                if (records[i].HeartRate < 60 || records[i].HeartRate > 100 ||
                    records[i].OxygenLevel < 90)
                {
                    Console.WriteLine("Status: ALERT - Abnormal Reading");
                }
                else
                {
                    Console.WriteLine("Status: Normal");
                }

                Console.WriteLine();
            }
        }
    }
}