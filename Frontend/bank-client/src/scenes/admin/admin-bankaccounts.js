/* eslint-disable no-unused-vars */
import React, { useState } from 'react'
import Button from '../../components/inputs/button/button'
import { post } from '../../helpers/api'
import { adminAPI } from '../../helpers/endpoints'
import Table from '@mui/material/Table'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TableHead from '@mui/material/TableHead'
import TableRow from '@mui/material/TableRow'
import Paper from '@mui/material/Paper'
import { useDispatch } from 'react-redux'
import { openNotification } from '../../redux/reducers/notification-reducer'

function AdminBankAccounts() {
	const [customerID, setCustomerID] = useState()
	const [bankAccounts, setBankAccounts] = useState()

	const dispatch = useDispatch()

	const getCustomerAccounts = (customerId) => {
		post(`${adminAPI}/bankaccounts`, customerId).then((response) => {
			setBankAccounts(response.data.data)
		}).catch(() => {
			dispatch(openNotification({
				type: 'error',
				message: 'Could not load bank accounts. Please check provided customer id.'
			}))
		})
	}

	const switchLockAccount = (accountNumber) => {
		post(`${adminAPI}/switchlock/bankaccount`, accountNumber).then(() => {
			dispatch(openNotification({
				type: 'success',
				message: 'Bank account status has been switched.'
			}))
			getCustomerAccounts(customerID)
		})
	}

	const style = {
		display: 'flex',
		'justifyContent': 'center',
		'marginTop': '40px',
		'marginBottom': '20px',
		gap: '10px',
	}

	return(
		<React.Fragment>
			<h3>Customer bank accounts</h3>
			<div style={style}>
				<input placeholder='Customer ID' onChange={(e) => setCustomerID(e.target.value)}></input>
				<Button style='accent' type='general' text='Get customer accounts' onClick={() => getCustomerAccounts(customerID)}></Button>
			</div>
			<TableContainer component={Paper}>
				<Table>
					<TableHead>
						<TableRow>
							<TableCell style={{'fontWeight': 'bold'}}>Account number</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Name</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Type</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Status</TableCell>
							<TableCell style={{'fontWeight': 'bold'}}>Actions</TableCell>
						</TableRow> 
					</TableHead>
					<TableBody>
						{
							bankAccounts
								? bankAccounts.map((account) => {
									return (
										<TableRow key={account.accountNumberNoSpace}>
											<TableCell>{account.accountNumber}</TableCell>
											<TableCell>{account.name}</TableCell>
											<TableCell>{account.type}</TableCell>
											<TableCell>{account.status}</TableCell>
											<TableCell>
												<Button style='accent' type='general' text='Switch bank account status' onClick={() => switchLockAccount(account.accountNumber)}></Button>
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

export default AdminBankAccounts