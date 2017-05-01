using NBitcoin.DataEncoders;
using NBitcoin.Protocol;
using System;
using Xunit;

namespace NBitcoin.Litecoin.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
			Networks.Register();
			BitcoinAddress.Create("LQQGtMCw3KgdpZHLzqysfYbqFpzgnigNjM", Networks.Mainnet);

			var header = new BlockHeader("01000000f615f7ce3b4fc6b8f61e8f89aedb1d0852507650533a9e3b10b9bbcc30639f279fcaa86746e1ef52d3edb3c4ad8259920d509bd073605c9bf1d59983752a6b06b817bb4ea78e011d012d59d4");
			Assert.Equal("adf6e2e56df692822f5e064a8b6404a05d67cccd64bc90f57f65b46805e9a54b", header.ToString());

			Assert.Equal("0000000110c8357966576df46f3b802ca897deb7ad18b12f1c24ecff6386ebd9", Networks.Mainnet.Consensus.GetPoWHash(header).ToString());

			var b = new Block(Encoders.Hex.DecodeData("01000000fff72f35940961576eed2bdf835fabf31f156eb70dc8bffba8dafb24e4b7222a59fd0dca84789b3a9bd7d6072a76c04a9bf908b5c6612c7103698eca4fe478f84f54964ef0ff0f1e7d0700000101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff08044f54964e02ed00ffffffff0100f2052a01000000434104bea01f8b8786e22697f0ec7060cc4009dd00eea3faf5b7e6245d56734b82d90291594295d724f772756accd8f78efe164cc5df8c0df4932d3c737213ea4c17aaac00000000"));
			Assert.True(b.CheckMerkleRoot());
			Assert.True(b.Header.CheckProofOfWork(Networks.Mainnet.Consensus));


			var genesis = Networks.Mainnet.GetGenesis();
			var b1 = new Block(Encoders.Hex.DecodeData("01000000e2bf047e7e5a191aa4ef34d314979dc9986e0f19251edaba5940fd1fe365a712f6509b1757baa71bc746e17cb4d0ed22e8935f71e2d0724336789021a40639fabfed8f4ef0ff0f1e7f2704000101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff07045dec8f4e0102ffffffff0100f2052a01000000434104284464458f95a72e610ecd7a561e8c2bdb46c491b347e4a375aa8f2e3b3ed56e99552e789265b6e52a2fc9a00edcdd6c032979dd81a7f1201b62427076768a7aac00000000"));

			var b2 = new Block(Encoders.Hex.DecodeData("010000008fc749ba1129b477844abee559079e4ed02cf9eab69e763de5020bd15e09ca80f27b45c33766594918ec67bd3a096dcc3a63fc015ce79821794e9fffa15743c5aafc944ef0ff0f1ed75e00000101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff07045cfc944e0101ffffffff0100f2052a0100000043410423bed815e3e0065bad6ac63b35db25f3986f60c50fd61e804e35fa0a25bf0c39fab3fbac3185dfcd75c6122fe69c72dd950ed95267911af8c11a341c5b8e09fcac00000000"));

			var chain = new ConcurrentChain(Networks.Mainnet);
			chain.SetTip(b1.Header);
			chain.SetTip(b2.Header);
			Assert.Equal(2, chain.Height);
			Assert.True(chain.Validate(Networks.Mainnet));
		}
    }
}
