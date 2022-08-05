import React from 'react'
import Card from '../../../../components/card/card'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'

import './cards-scene.scss'

function CardsScene() {
	return (
		<DashboardSection 
			title='My cards' 
			emptyChildrenText='you have no cards yet' 
			option={<Button style='accent' icon='add' text='New card'></Button>}>
			<div className='cardsContainer'>
				<Card cardStyle="card1" cardNo="1001000000001001" expiration="10/22" type='Credit'/>
				<Card cardStyle="card2" cardNo="0000000000000000" expiration="10/22" type='Debit'/>
				<Card cardStyle="card3" cardNo="0000000000000000" expiration="10/22" type='Debit'/>
				<Card cardStyle="card4" cardNo="0000000000000000" expiration="10/22" type='Credit'/>
			</div>
		</DashboardSection>
	)
}

export default CardsScene