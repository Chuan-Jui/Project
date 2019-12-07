const Web3 = require('web3');
const solc = require('solc');
const fs = require('fs');
const TX = require('ethereumjs-tx').Transaction;

// Connect to ropsten
const web3 = new Web3(
    new Web3.providers.HttpProvider("https://:PROJECT_SECRET@ropsten.infura.io/v3/PROJECT_ID")
)

var contracts_path = "./contracts/OMGToken.sol"

var input = fs.readFileSync(contracts_path, 'utf8');

// 1 activates the optimiser
var output = solc.compile(input, 1);

const abi = output.contracts[':OMGToken'].interface;
const contract_address = '0xaaccb771fd7c9d0d962abee32c7f98e0779daf6d';
const account = '0x2fb0b05e3c8874043e4c0fba74851a9fa1cb1f8e'
const privkey = Buffer.from('af3e8eeab4af011b71e4eb2b06ebb51044f34e009bb5df30e3fd23dc16c78f6a', 'hex')

// interact with a contract
async function balanceof() {
    const contract = await new web3.eth.Contract(JSON.parse(abi), contract_address);
    contract.methods.balanceOf(account).call().then(console.log);
};

async function getToeknName() {
    const contract = await new web3.eth.Contract(JSON.parse(abi), contract_address);
    contract.methods.name().call().then(console.log);
};

async function mint() {
    const contract = await new web3.eth.Contract(JSON.parse(abi), contract_address);
    const nonce = await web3.eth.getTransactionCount(account);
    
    const txObject = {
        nonce:    web3.utils.toHex(nonce),
        to:       contract_address,
        gasLimit: web3.utils.toHex(100000),
        gasPrice: web3.utils.toHex(web3.utils.toWei('10', 'gwei')),
        data:     contract.methods.mint(account, 1000000).encodeABI()
    }

    var tx = new TX(txObject, {'chain': 'ropsten'});
    tx.sign(privkey);
    
    const serializedTX = tx.serialize();
    const rawTX = '0x' + serializedTX.toString('hex');
  
    web3.eth.sendSignedTransaction(rawTX, (err, txHash) => {
        console.log('txHash:', txHash);
    })
};

balanceof();
getToeknName();
mint();
balanceof();
