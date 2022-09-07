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
					const balance = account.balance.toString().split('.')
					return (<BankAccountQuickview
						accountKey={account.accountNumberNoSpace}
						type={account.type}
						name={account.name}
						accountNumber={account.accountNumber}
						isLocked={account.status === 'Locked'}
						fulls={balance[0]}
						cents={balance[1] ? balance[1] : '00'}
					/>)
				})
			} />
		</div>
	)
}

export default AccountsContainer