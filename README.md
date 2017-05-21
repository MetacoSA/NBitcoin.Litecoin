# NBitcoin.Litecoin

This project allows NBitcoin to support Litecoin.
To register Litecoin extensions, run:

```
NBitcoin.Litecoin.Networks.Register();
```

You can then use NBitcoin with `NBitcoin.Litecoin.Networks.Mainnet` or `NBitcoin.Litecoin.Networks.Testnet`.
Alternatively you can use `NBitcoin.Network.GetNetwork("ltc-main")` to get the Network object.
You can then start using Litecoin in the same way you do with Bitcoin.

