// import package
const Web3 = require('web3');

// set a provider
const web3 = new Web3('http://localhost:8545');

let privkey = "0xaf3e8eeab4af011b71e4eb2b06ebb51044f34e009bb5df30e3fd23dc16c78f6a";
let wallet = web3.eth.accounts.privateKeyToAccount(privkey);

// 0x2fb0b05e3c8874043e4c0fba74851a9fa1cb1f8e
console.log(wallet.address)

let nonce = web3.eth.getTransactionCount(wallet.address)
.then((transactionCount) => {
    return transactionCount;
});

// create a transaction
let rawTransaction = {
    nonce: nonce,
    gas: 21000,
    gasPrice: "20000000000",
    to: "0xF0109fC8DF283027b6285cc889F5aA624EaC1F55",
    value: web3.utils.toHex(web3.utils.toWei('1', 'ether')),
    data: "0x",
    chainId: 1
};

// sign and send a transaction
wallet.signTransaction(rawTransaction)
.then(signedTx => web3.eth.sendSignedTransaction(signedTx.rawTransaction))
.then(receipt => console.log("Transaction receipt:", receipt))
.catch(err => console.error(err));
