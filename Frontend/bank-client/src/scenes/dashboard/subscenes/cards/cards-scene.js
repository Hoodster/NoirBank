import React from 'react'
import { useDispatch } from 'react-redux'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'
import { ADD_CARD } from '../../../../modals/constants'
import { open } from '../../../../redux/reducers/modal-reducer'

import CardsContainer from './components/cards-container/cards-container'

function CardsScene() {
	const dispatch = useDispatch()

	const addCardModal = () => {
		dispatch(open(ADD_CARD))
	}

	return (
		<DashboardSection
			title='My cards'
			emptyChildrenText='you have no cards yet'
			height='sm'
			option={<Button style='accent' type='general' icon='add' onClick={addCardModal} text='New card'></Button>}>
			<CardsContainer />
		</DashboardSection>
	)
}

export default CardsScene