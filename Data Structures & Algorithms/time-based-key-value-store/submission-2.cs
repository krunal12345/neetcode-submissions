public class TimeMap {
    Dictionary<string, List<(int ts, string v)>> dataDict;
    public TimeMap() {
        dataDict = new Dictionary<string, List<(int t, string v)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        List<(int t, string v)> data = dataDict.GetValueOrDefault(key, null);
        if(data == null){
            data = new List<(int t, string v)>();
            dataDict.Add(key, data);
        }
        data.Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        List<(int t, string v)> data = dataDict.GetValueOrDefault(key, null);
        if(data == null) return "";

        return binarySearch(data, timestamp);
    }

    public string binarySearch(List<(int t, string v)> data, int timestamp){
        if(data.Count == 1 && data[0].t > timestamp) return "";

        int left = 0;
        int right = data.Count - 1;
        int largestTimeStampIndex = -1;

        while(left <= right){
            int mid = left + (right - left) / 2;
            if(data[mid].t == timestamp) return data[mid].v;
            if(data[mid].t <= timestamp){
                largestTimeStampIndex = mid;
            }
             
            if(data[mid].t < timestamp){
                left = mid + 1;
            }else{
                right = mid - 1;
            }
        }

        return largestTimeStampIndex == -1 ? "" : data[largestTimeStampIndex].v;
    }
}
