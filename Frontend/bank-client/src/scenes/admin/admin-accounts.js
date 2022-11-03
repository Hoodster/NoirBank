import React, { useEffect, useState } from 'react'
import Table from '@mui/material/Table'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import Paper from '@mui/material/Paper'
import { get, post } from '../../helpers/api'
import { adminAPI } from '../../helpers/endpoints'
import Button from '../../components/inputs/button/button'
import { useDispatch } from 'react-redux'
import { openNotification } from '../../redux/reducers/notification-reducer'

function AdminAccounts() {
	const [accounts, setAccounts] = useState()
	const dispatch = useDispatch()

	useEffect(() => {
		getAllUsers()
	}, [])

	const getAllUsers = () => {
		get(`${adminAPI}/accounts`).then((response) => {
			setAccounts(response.data.data)
		})
	}

	const switchLockAccount = (userId) => {
		post(`${adminAPI}/switchlock/account`, userId).then(() => {
			dispatch(openNotification({
				type: 'success',
				message: 'User account status has been switched.'
			}))
			getAllUsers()
		}).catch(() => {
			dispatch(openNotification({
				type: 'error',
				message: 'Unable to switch account status. Not enough failed logins in a row.'
			}))
		})
	}
    
	return (
		<React.Fragment>
			<h3>Users</h3>  
			<TableContainer component={Paper}>
				<Table>
					<TableHead>
						<TableRow>
							<TableCell style={{'fontWeight': 'bold'}}>ID</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Name</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Account Type</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Status</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Actions</TableCell>
						</TableRow> 
					</TableHead>
					<TableBody>
						{
							accounts 
								? accounts.map((account) => {
									return (
										<TableRow key={account.id}>
											<TableCell>{account.id}</TableCell>
											<TableCell>{account.name}</TableCell>
											<TableCell>{account.accountType}</TableCell>
											<TableCell>{account.status}</TableCell>
											<TableCell>
												<Button buttonStyle='accent' type='general' text='Switch account activity' onClick={() => switchLockAccount(account.id)}></Button>
											</TableCell>
										</TableRow>
									)
								})
								: (
									<TableRow>
										<TableCell align='center'>No Data To Show</TableCell>
									</TableRow>
								)
						}
					</TableBody>
				</Table>
			</TableContainer>
		</React.Fragment>
	)
}

export default AdminAccounts