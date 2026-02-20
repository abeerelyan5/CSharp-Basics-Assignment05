public enum DayOfWeek { Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday }

public enum Grade { A, B, C, D, F }

public class Assignment05Solution
{
    public static void Main()
    {
        Console.WriteLine("Part 1: Enums Q1");
        Console.WriteLine("\n================\n");

        Console.Write("Enter a day number (1-7): ");

        if (int.TryParse(Console.ReadLine(), out int DayNumber) && DayNumber >= 1 && DayNumber <= 7)
        {
            DayOfWeek SelectedDay = (DayOfWeek)(DayNumber - 1);
            Console.WriteLine($"Day: {SelectedDay}");

            switch (SelectedDay)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("It's the Weekend");
                    break;
                default:
                    Console.WriteLine("It's a Workday");
                    break;
            }
        }
        else
            Console.WriteLine("Invalid input.");



        Console.WriteLine("\n=================\n");



        Console.WriteLine("\nPart 2: Arrays Q1");
        Console.WriteLine("\n=================\n");

        Console.Write("Enter the size of the array: ");
        int ArraySize = int.Parse(Console.ReadLine());
        int[] NumbersArray = new int[ArraySize];

        for (int i = 0; i < ArraySize; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            NumbersArray[i] = int.Parse(Console.ReadLine());
        }

        if (ArraySize > 0)
        {
            int SumResult = 0;
            int MaxValue = NumbersArray[0];
            int MinValue = NumbersArray[0];

            for (int i = 0; i < ArraySize; i++)
            {
                SumResult += NumbersArray[i];
                if (NumbersArray[i] > MaxValue) MaxValue = NumbersArray[i];
                if (NumbersArray[i] < MinValue) MinValue = NumbersArray[i];
            }

            double AverageResult = (double)SumResult / ArraySize;

            Console.WriteLine($"Sum     = {SumResult}");
            Console.WriteLine($"Average = {AverageResult}");
            Console.WriteLine($"Max     = {MaxValue}");
            Console.WriteLine($"Min     = {MinValue}");

            Console.Write("Reverse = ");
            for (int i = ArraySize - 1; i >= 0; i--)
            {
                Console.Write(NumbersArray[i]);
                if (i > 0) Console.Write(", ");
            }

            Console.WriteLine();
        }



        Console.WriteLine("\n=================\n");
        
        
        
        Console.WriteLine("\nPart 2: Arrays Q2");
        Console.WriteLine("\n=================\n");

        int[,] StudentGradesMatrix = new int[3, 4];
        int TotalClassSum = 0;
        int TotalGradesCount = 3 * 4;

        for (int StudentIndex = 0; StudentIndex < 3; StudentIndex++)
        {
            Console.WriteLine($"Enter grades for Student {StudentIndex + 1}:");
            for (int SubjectIndex = 0; SubjectIndex < 4; SubjectIndex++)
            {
                Console.Write($"Subject {SubjectIndex + 1}: ");
                StudentGradesMatrix[StudentIndex, SubjectIndex] = int.Parse(Console.ReadLine());
            }
        }

        for (int StudentIndex = 0; StudentIndex < 3; StudentIndex++)
        {
            int StudentSum = 0;
            for (int SubjectIndex = 0; SubjectIndex < 4; SubjectIndex++)
            {
                StudentSum += StudentGradesMatrix[StudentIndex, SubjectIndex];
                TotalClassSum += StudentGradesMatrix[StudentIndex, SubjectIndex];
            }
            Console.WriteLine($"Student {StudentIndex + 1} Average: {(double)StudentSum / 4}");
        }

        Console.WriteLine($"Overall Class Average: {(double)TotalClassSum / TotalGradesCount}");



        Console.WriteLine("\n====================\n");



        Console.WriteLine("\nPart 3: Functions Q1");
        Console.WriteLine("\n====================\n");

        Console.Write("Enter first number: ");
        double FirstNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double SecondNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter operation (+, -, *, /): ");
        char OperationSymbol = char.Parse(Console.ReadLine());

        switch (OperationSymbol)
        {
            case '+':
                Console.WriteLine($"Result: {AddNumbers(FirstNumber, SecondNumber)}");
                break;
            case '-':
                Console.WriteLine($"Result: {SubtractNumbers(FirstNumber, SecondNumber)}");
                break;
            case '*':
                Console.WriteLine($"Result: {MultiplyNumbers(FirstNumber, SecondNumber)}");
                break;
            case '/':
                if (SecondNumber == 0)
                    Console.WriteLine("Cannot divide by zero.");
                else
                    Console.WriteLine($"Result: {DivideNumbers(FirstNumber, SecondNumber)}");
                break;
            default:
                Console.WriteLine("Invalid operation.");
                break;
        }


        
        Console.WriteLine("\n====================\n");



        Console.WriteLine("\nPart 3: Functions Q2");
        Console.WriteLine("\n====================\n");

        Console.Write("Enter circle radius: ");
        double CircleRadius = double.Parse(Console.ReadLine());

        CalculateCircle(CircleRadius, out double CircleArea, out double CircleCircumference);

        Console.WriteLine($"Area: {CircleArea}");
        Console.WriteLine($"Circumference: {CircleCircumference}");

        Console.WriteLine("\n--- Report ---");
        int[] FinalStudentScores = new int[5];

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter score for Student {i + 1}: ");
            FinalStudentScores[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();
        for (int i = 0; i < 5; i++)
        {
            Grade StudentGradeValue = GetGrade(FinalStudentScores[i]);
            Console.WriteLine($"Student {i + 1}: {FinalStudentScores[i]} -> Grade: {StudentGradeValue}");
        }

        double ClassAverageScore = CalculateAverage(FinalStudentScores);
        GetMinMax(FinalStudentScores, out int MinClassScore, out int MaxClassScore);

        Console.WriteLine($"\nAverage: {ClassAverageScore}");
        Console.WriteLine($"Highest Score: {MaxClassScore}");
        Console.WriteLine($"Lowest Score: {MinClassScore}");
    }

    public static double AddNumbers(double FirstOperand, double SecondOperand)
    {
        return FirstOperand + SecondOperand;
    }

    public static double SubtractNumbers(double FirstOperand, double SecondOperand)
    {
        return FirstOperand - SecondOperand;
    }

    public static double MultiplyNumbers(double FirstOperand, double SecondOperand)
    {
        return FirstOperand * SecondOperand;
    }

    public static double DivideNumbers(double FirstOperand, double SecondOperand)
    {
        return FirstOperand / SecondOperand;
    }

    public static void CalculateCircle(double RadiusValue, out double AreaValue, out double CircumferenceValue)
    {
        AreaValue = Math.PI * RadiusValue * RadiusValue;
        CircumferenceValue = 2 * Math.PI * RadiusValue;
    }

    public static Grade GetGrade(int ScoreValue)
    {
        if (ScoreValue >= 90) return Grade.A;
        if (ScoreValue >= 80) return Grade.B;
        if (ScoreValue >= 70) return Grade.C;
        if (ScoreValue >= 60) return Grade.D;
        return Grade.F;
    }

    public static double CalculateAverage(int[] ScoresArray)
    {
        int TotalSum = 0;

        for (int i = 0; i < ScoresArray.Length; i++)
            TotalSum += ScoresArray[i];

        return (double)TotalSum / ScoresArray.Length;
    }

    public static void GetMinMax(int[] ScoresArray, out int MinimumScore, out int MaximumScore)
    {
        MinimumScore = ScoresArray[0];
        MaximumScore = ScoresArray[0];

        for (int i = 1; i < ScoresArray.Length; i++)
        {
            if (ScoresArray[i] < MinimumScore) MinimumScore = ScoresArray[i];
            if (ScoresArray[i] > MaximumScore) MaximumScore = ScoresArray[i];
        }
    }
}
