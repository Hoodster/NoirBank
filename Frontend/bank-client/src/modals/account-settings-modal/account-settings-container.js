import React, { useEffect, useState } from 'react'
import { get } from '../../helpers/api'
import { customerAPI } from '../../helpers/endpoints'
import { getAccountInfo } from './selectors'

function AccountSettingsContainer(props) {
	const account = getAccountInfo()
	const isAdmin = account.login.includes('adm')
	const [customerAddress, setCustomerAddress] = useState(null)
	
	useEffect(() => {
		if (!isAdmin) {
			get(`${customerAPI}/address`).then((response) =>  setCustomerAddress(response.data.data))
		}
	},[])

	return (
		<div>
			<h3>{`${account.firstName} ${account.lastName}`}</h3>
			<div>
				<h5>Type</h5>
				<span>{isAdmin ? 'Administrator' : 'Customer'}</span>
			</div>
			<div>
				<h5>Contact</h5>
				{
					props.editMode 
						? <input id='account-edit-email' type='email' defaultValue={account.email} />
						: <span>{account.email}</span>
				}
			</div>
			{
				!isAdmin ?
					<div>
						<h5>Home Address</h5>
						<span>{`${customerAddress?.street} ${customerAddress?.building}${customerAddress?.apartment ? `/${customerAddress.apartment}` : ''}`}</span>
						<br/>
						<span>{`${customerAddress?.postalCode} ${customerAddress?.city}`}</span>
						<br/>
						<span>{customerAddress?.country}</span>
					</div>
					: null
			}
		</div>
	)
}

export default AccountSettingsContainer