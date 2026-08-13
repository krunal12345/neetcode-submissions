public class Twitter
{
    private int time = 0;

    private Dictionary<int, HashSet<int>> followMap = new();
    private Dictionary<int, List<(int tweetId, int time)>> tweetMap = new();

    public Twitter()
    {
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweetMap.ContainsKey(userId))
            tweetMap[userId] = new();

        tweetMap[userId].Add((tweetId, time));
        time++;
    }

    public List<int> GetNewsFeed(int userId)
    {
        var result = new List<int>();

        // (userId, index in that user's tweet list)
        var pq = new PriorityQueue<(int userId, int index), int>();

        // Add user's own latest tweet
        AddLatestTweet(userId, pq);

        // Add latest tweet of every followee,
        // except userId because it was already added above.
        if (followMap.TryGetValue(userId, out var followees))
        {
            foreach (int followeeId in followees)
            {
                if (followeeId == userId)
                    continue;

                AddLatestTweet(followeeId, pq);
            }
        }

        while (pq.Count > 0 && result.Count < 10)
        {
            var (currentUserId, index) = pq.Dequeue();

            var tweet = tweetMap[currentUserId][index];

            result.Add(tweet.tweetId);

            // Add the next older tweet from the same user
            if (index > 0)
            {
                int nextIndex = index - 1;

                pq.Enqueue(
                    (currentUserId, nextIndex),
                    -tweetMap[currentUserId][nextIndex].time
                );
            }
        }

        return result;
    }

    private void AddLatestTweet(
        int userId,
        PriorityQueue<(int userId, int index), int> pq)
    {
        if (!tweetMap.TryGetValue(userId, out var tweets))
            return;

        int index = tweets.Count - 1;

        pq.Enqueue(
            (userId, index),
            -tweets[index].time
        );
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!followMap.ContainsKey(followerId))
            followMap[followerId] = new();

        followMap[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (followMap.TryGetValue(followerId, out var followees))
        {
            followees.Remove(followeeId);
        }
    }
}