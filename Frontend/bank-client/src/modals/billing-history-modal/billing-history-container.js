import React from 'react'
import Table from '@mui/material/Table'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import Paper from '@mui/material/Paper'
import { getModalData } from '../add-card-modal/selectors'

function BillingHistoryContainer() {
	const accounts = getModalData().accounts
	return (
		<TableContainer component={Paper}>
			<Table>
				<TableHead>
					<TableRow>
						<TableCell style={{'fontWeight': 'bold'}}>Account name</TableCell>
						<TableCell style={{'fontWeight': 'bold'}}>Title</TableCell>
						<TableCell style={{'fontWeight': 'bold'}}>Amount</TableCell>
						<TableCell style={{'fontWeight': 'bold'}}>Type</TableCell>
						<TableCell style={{'fontWeight': 'bold'}}>Date</TableCell>
					</TableRow> 
				</TableHead>
				<TableBody>
					{
						accounts ? accounts.map(account => {
							const isIncome = account.transactionType === 0
							return (
								<TableRow key={Math.random()}>
									<TableCell style={!isIncome ? { 'color': 'red'} : null} >{account.accountName}</TableCell>
									<TableCell  style={!isIncome ? { 'color': 'red'} : null} >{account.title}</TableCell>
									<TableCell style={!isIncome ? { 'color': 'red'} : null} >{!isIncome?'-':''}{account.amount} PLN</TableCell>
									<TableCell style={!isIncome ? { 'color': 'red'} : null} >{account.operationType}</TableCell>
									<TableCell style={!isIncome ? { 'color': 'red'} : null} >{account.operationDate}</TableCell>
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