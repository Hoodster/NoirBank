import React from 'react'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'
import AccountsContainer from './components/accounts-container/accounts-container'

function AccountsScene() {
	return <DashboardSection
		title='My accounts'
		emptyChildrenText='you have no accounts yet'
		height='sm'
		option={<Button style='accent' icon='add' type='general' text='New account'></Button>}>
		<AccountsContainer/>
	</DashboardSection>
}

export default AccountsScene