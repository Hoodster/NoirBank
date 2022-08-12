/* eslint-disable react/jsx-key */
import React from 'react'
import BankAccountQuickview from '../../../../../../components/bank-account-quickview/quick-view'
import Swipeable from '../../../../../../components/swipeable/swipeable'
import './accounts-container.scss'

function AccountsContainer() {
	return (
		<div className='accounts-container'>
			<Swipeable space={30} data={[
				<BankAccountQuickview/>,
				<BankAccountQuickview/>,
				<BankAccountQuickview/>,
				<BankAccountQuickview/>,]} />
		</div>
	)
}

export default AccountsContainer