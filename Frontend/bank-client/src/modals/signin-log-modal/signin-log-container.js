import React from 'react'
import Table from '@mui/material/Table'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import Paper from '@mui/material/Paper'
import { getModalData } from './selectors'

function SignInLogContainer() {
	const logs = getModalData().logs

	return (
		<TableContainer component={Paper}>
			<Table>
				<TableHead>
					<TableRow>
						<TableCell style={{'fontWeight': 'bold'}}>ID</TableCell>
						<TableCell style={{'fontWeight': 'bold'}}>Date</TableCell>
						<TableCell style={{'fontWeight': 'bold'}}>Status</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					{
						logs ? logs.map(log => {
							const isSuccessfull = log.isSuccessfull === 'Succeed'
							return (
								<TableRow key={Math.random()}>
									<TableCell style={!isSuccessfull ? { 'color': 'red'} : null}>{log.sessionID.substring(0,7)}</TableCell>
									<TableCell style={!isSuccessfull ? { 'color': 'red'} : null}>{log.sessionDate}</TableCell>
									<TableCell style={!isSuccessfull ? { 'color': 'red'} : null}>{log.isSuccessfull}</TableCell>
								</TableRow>
							)
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

export default SignInLogContainer