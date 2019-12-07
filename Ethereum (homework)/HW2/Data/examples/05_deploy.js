const Web3 = require('web3');
const solc = require('solc');
const fs = require('fs');
const TX = require('ethereumjs-tx').Transaction;

// // Connect to local node
// const web3 = new Web3('http://localhost:8545');
// Connect to ropsten
const web3 = new Web3(
    new Web3.providers.HttpProvider("https://:PROJECT_SECRET@ropsten.infura.io/v3/PROJECT_ID")
)

var contracts_path = "./contracts/OMGToken.sol"

var input = fs.readFileSync(contracts_path, 'utf8');

// 1 activates the optimiser
var output = solc.compile(input, 1);
// console.log(output);

// for (var contract_name in output.contracts) {
//     console.log(contract_name + ': ' + output.contracts[contract_name].bytecode);
//     console.log(contract_name + '; ' + JSON.parse(output.contracts[contract_name].interface));
// }

const bytecode = output.contracts[':OMGToken'].bytecode;
const abi = output.contracts[':OMGToken'].interface;
// console.log(bytecode);
// console.log(abi);

const account = '0x2fb0b05e3c8874043e4c0fba74851a9fa1cb1f8e'
const privkey = Buffer.from('af3e8eeab4af011b71e4eb2b06ebb51044f34e009bb5df30e3fd23dc16c78f6a', 'hex')

// deploy a contract
async function deploy() {

    const nonce = await web3.eth.getTransactionCount(account);
    const txObject = {
        nonce:    web3.utils.toHex(nonce),
        gasLimit: web3.utils.toHex(4700000),
        gasPrice: web3.utils.toHex(web3.utils.toWei('10', 'gwei')),
        data: '0x' + bytecode
    }

    var tx = new TX(txObject, {'chain': 'ropsten'});
    tx.sign(privkey);
    
    const serializedTX = tx.serialize();
    const rawTX = '0x' + serializedTX.toString('hex');
  
    web3.eth.sendSignedTransaction(rawTX, (err, txHash) => {
        console.log('txHash:', txHash);
    })

};

deploy();
