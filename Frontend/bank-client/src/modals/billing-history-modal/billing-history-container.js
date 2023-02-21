import React from 'react'
import Table from '@mui/material/Table'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import Paper from '@mui/material/Paper'
import { getModalData } from '../add-card-modal/selectors'
import Button from '../../components/inputs/button/button'
import { transactionAPI } from '../../helpers/endpoints'

function BillingHistoryContainer() {
	const transactions = getModalData()?.accounts
	const headers = [
		'Account name',
		'Title',
		'Amount',
		'Type',
		'Date',
		'Actions'
	]

	const generateTransactionPDF = (transactionID) => {
		open(`${transactionAPI}/pdf?transactionID=${transactionID}`)
	}

	return (
		<TableContainer style={{'maxHeight': '400px'}} component={Paper}>
			<Table>
				<TableHead>
					<TableRow>
						{
							headers.map(header => <TableCell key={Math.random()} style={{'fontWeight': 'bold'}}>{header}</TableCell>)
						}
					</TableRow> 
				</TableHead>
				<TableBody>
					{
						transactions ? transactions.map(transaction => {
							const isIncome = transaction.transactionType === 'Income'
							return (
								<TableRow key={Math.random()}>
									<TableCell>{transaction.accountName}</TableCell>
									<TableCell>{transaction.title}</TableCell>
									<TableCell style={!isIncome ? { 'color': 'red'} : null} >{!isIncome?'-':''}{transaction.amount} PLN</TableCell>
									<TableCell>{transaction.operationType}</TableCell>
									<TableCell>{transaction.operationDate}</TableCell>
									<TableCell>
										<Button text='Generate PDF' type='general' buttonStyle='accent' onClick={() => generateTransactionPDF(transaction.transactionID)}/>
									</TableCell>
								</TableRow>
							)
						}) : 
							<TableRow>
								<TableCell align='center'>No Data To Show</TableCell>
							</TableRow>
					}
				</TableBody>
			</Table>
		</TableContainer>
	)
}

export default BillingHistoryContainer