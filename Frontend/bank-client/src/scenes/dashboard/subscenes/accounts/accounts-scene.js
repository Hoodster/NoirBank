import React from 'react'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'

function AccountsScene() {
	return <DashboardSection
		title='My accounts'
		emptyChildrenText='you have no accounts yet'
		option={<Button style='accent' icon='add' type='general' text='New account'></Button>}>
	</DashboardSection>
}

export default AccountsScene