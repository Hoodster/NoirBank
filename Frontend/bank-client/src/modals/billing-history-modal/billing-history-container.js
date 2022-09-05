import React from 'react'
import Table from '@mui/material/Table'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import Paper from '@mui/material/Paper'

function BillingHistoryContainer(props) {
	return (
		<TableContainer component={Paper}>
			<Table>
				<TableHead>
					<TableRow>
						<TableCell>ID</TableCell>
						<TableCell align='right'>Date</TableCell>
						<TableCell align='right'>Succeed</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					{
						(props.logs?.length > 0) ? props.logs.map(log => {
							<TableRow>
								<TableCell>{log.SessionLogID}</TableCell>
								<TableCell>{log.Date}</TableCell>
								<TableCell>{log.IsSuccessfull === 1}</TableCell>
							</TableRow>
						}) : 
							<TableRow>
								<TableCell></TableCell>
								<TableCell align='center'>No Data To Show</TableCell>
								<TableCell></TableCell>
							</TableRow>
					}
				</TableBody>
			</Table>
		</TableContainer>
	)
}

export default BillingHistoryContainer