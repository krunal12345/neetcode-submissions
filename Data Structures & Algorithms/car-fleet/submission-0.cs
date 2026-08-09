public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        List<(int position, int speed)> cars = new();

        for (int i = 0; i < position.Length; i++)
        {
            cars.Add((position[i], speed[i]));
        }

        // Closest to target first
        cars = cars.OrderByDescending(car => car.position).ToList();

        Stack<double> stack = new();

        foreach (var car in cars)
        {
            double time = (double)(target - car.position) / car.speed;

            // If this car takes longer than the fleet ahead,
            // it cannot catch that fleet.
            if (stack.Count == 0 || time > stack.Peek())
            {
                stack.Push(time);
            }
        }

        return stack.Count;
    }
}