/* eslint-disable react/jsx-key */
import React from 'react'
import BankAccountQuickview from '../../../../../../components/bank-account-quickview/quick-view'
import Swipeable from '../../../../../../components/swipeable/swipeable'
import './accounts-container.scss'

function AccountsContainer(props) {
	return (
		<div className='accounts-container'>
			<Swipeable space={30} data={
				props.accounts.map(account => {
					return (<BankAccountQuickview
						type={account.type}
						name={account.name}
						accountNumber={account.accountNumber}
						fulls={account.balance}
						cents={'00'}
					/>)
				})
			} />
		</div>
	)
}

export default AccountsContainer