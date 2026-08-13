public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        int[] remaining = new int[26];
        int[] lastPosition = new int[26];

        // -1 or any sufficiently negative number means
        // the task has never been executed.
        Array.Fill(lastPosition, -1000);

        // Count each task
        foreach (char task in tasks)
        {
            remaining[task - 'A']++;
        }

        int current = 0;
        int completed = 0;

        while (completed < tasks.Length)
        {
            int selected = -1;

            // Find the available task with highest frequency
            for (int i = 0; i < 26; i++)
            {
                if (remaining[i] == 0)
                    continue;

                // Still cooling down
                if (current - lastPosition[i] <= n)
                    continue;

                if (selected == -1 ||
                    remaining[i] > remaining[selected])
                {
                    selected = i;
                }
            }

            if (selected != -1)
            {
                remaining[selected]--;
                lastPosition[selected] = current;
                completed++;
            }

            // Move to next CPU cycle
            current++;
        }

        return current;
    }
}