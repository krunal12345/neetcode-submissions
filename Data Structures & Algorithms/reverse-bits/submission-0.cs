public class Solution {
    public uint ReverseBits(uint n) {
        // 110011001010
        // 010100110011
        uint result = 0;
        for(int i = 0; i < 32; i++){
            var lastBit = (n >> i) & 1;
            result = (result << 1) | lastBit;
        }

        return result;

    }
}
