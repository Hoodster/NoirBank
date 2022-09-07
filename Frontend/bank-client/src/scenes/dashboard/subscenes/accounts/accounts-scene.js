import React, { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'
import { get } from '../../../../helpers/api'
import { bankAccountAPI } from '../../../../helpers/endpoints'
import { CREATE_ACCOUNT } from '../../../../modals/constants'
import { open } from '../../../../redux/reducers/modal-reducer'
import { addBankAccounts } from '../../../../redux/reducers/user-reducer'
import AccountsContainer from './components/accounts-container/accounts-container'
import { getAccounts } from './selectors'

function AccountsScene() {
	const dispatch = useDispatch()
	const bankAccounts = getAccounts()

	useEffect(() => {
		get(`${bankAccountAPI}`)
			.then(response => dispatch(addBankAccounts(response.data.data)))
	}, [])

	const createAccountModal = () => {
		dispatch(open(CREATE_ACCOUNT))
	}

	const hasNoAccounts = bankAccounts.length === 0

	return <DashboardSection
		title='My accounts'
		emptyChildrenText='you have no accounts yet'
		height='sm'
		option={<Button style='accent' icon='add' type='general' onClick={createAccountModal} text='New account'></Button>}>
		{!hasNoAccounts ? <AccountsContainer accounts={bankAccounts} /> : null}
	</DashboardSection>
}

export default AccountsScene