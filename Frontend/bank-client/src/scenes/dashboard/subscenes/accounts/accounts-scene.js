import React from 'react'
import { useDispatch } from 'react-redux'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'
import { open } from '../../../../redux/reducers/modal-reducer'
import AccountsContainer from './components/accounts-container/accounts-container'

function AccountsScene() {
	const dispatch = useDispatch()

	const createAccountModal = () => {
		dispatch(open())
	}

	return <DashboardSection
		title='My accounts'
		emptyChildrenText='you have no accounts yet'
		height='sm'
		option={<Button style='accent' icon='add' type='general' onClick={createAccountModal} text='New account'></Button>}>
		<AccountsContainer />
	</DashboardSection>
}

export default AccountsScene