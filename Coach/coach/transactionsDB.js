const writeJsonFile = require('write-json-file');
var csv = require("csvtojson");
var csv_path = 'data/sampleTransactions.csv';
var transactions;

// Parses the transactions from a CSV file and sorts the transactions in chronological order
csv()
    .fromFile(csv_path)
    .on("end_parsed", function (jsonArrayObj) {
        transactions = jsonArrayObj;
        console.log(Object.keys(transactions).length + " transactions parsed from " + csv_path);
        transactions.sort(sortByDate);
    })

function saveFile() {
    writeJsonFile('data.json', transactions).then(() => {
        console.log('data.json saved');
    });
}

// The total amount of transactions
function getTransactionCount() {
    return Object.keys(transactions).length;
}
// Retrieve a transaction based on the index in the collection
function getTransactionByIndex(index) {
    return transactions[index];
}

// Returns list of all transactions that originated from the specified account
function getTransactionsFromAccount(accountNumber) {
    let transactions = [];
    for (i = 0; i < getTransactionCount(); i++) {
        let t = getTransactionByIndex(i)
        account = t.PaymentFrom
        if (account && account === accountNumber) {
            transactions.push(t)
        }
    }
    return transactions
}

// Returns a list of all transactions that originated from the specified account
function getTransactionsToAccount(accountNumber) {
    let transactions = [];
    for (i = 0; i < getTransactionCount(); i++) {
        let t = getTransactionByIndex(i)
        account = t.PaymentTo
        if (account && account === accountNumber) {
            transactions.push(t)
        }
    }
    return transactions
}

// Comparator function for sorting the JSON objects by date
function sortByDate(a, b){
    return new Date(a.Date).getTime() - new Date(b.Date).getTime();
}


function addNewTransaction(paymentID,     // ID associated with the payment
                           transactionID, // ID associated with the transaction
                           paymentType,   // The type of payment that was made
                           paymentFrom,   // The account number of the sender
                           paymentTo,     // The account number of the receiver
                           amount,        // The amount of money in NOK
                           kidOrMessage,  // The message or KID number
                           date)          // Timestamp of the transaction
{
    // TODO add a transaction (Prepend?)
    let NewTransaction = {
        PaymentId: paymentID,
        TransactionId: transactionID,
        PaymentType: paymentType,
        PaymentFrom: paymentFrom,
        PaymentTo: paymentTo,
        PaymentAmount: amount,
        KidMessage: kidOrdMessage,
        Date: date
    }
}

function
*/
module.exports = {
    getTransactionCount,
    getTransactionByIndex
}
