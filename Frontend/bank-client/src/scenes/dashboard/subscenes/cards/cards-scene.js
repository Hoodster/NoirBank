import React from 'react'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'

import CardsContainer from './components/cards-container/cards-container'

function CardsScene() {
	return (
		<DashboardSection 
			title='My cards' 
			emptyChildrenText='you have no cards yet' 
			height='sm'
			option={<Button style='accent' type='general' icon='add' text='New card'></Button>}>
			<CardsContainer/>
		</DashboardSection>
	)
}

export default CardsScene