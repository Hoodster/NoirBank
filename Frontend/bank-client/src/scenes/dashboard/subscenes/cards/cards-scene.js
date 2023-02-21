/* eslint-disable no-constant-condition */
import React, { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import Button from '../../../../components/inputs/button/button'
import { get } from '../../../../helpers/api'
import { cardAPI } from '../../../../helpers/endpoints'
import { ADD_CARD } from '../../../../modals/constants'
import { open } from '../../../../redux/reducers/modal-reducer'
import { addCards } from '../../../../redux/reducers/user-reducer'

import CardsContainer from './components/cards-container/cards-container'
import { getCards } from './selectors'

function CardsScene() {
	const dispatch = useDispatch()
	const cards = getCards()

	useEffect(() => {
		get(`${cardAPI}/all`)
			.then(response => dispatch(addCards(response.data.data)))
	}, [])

	const addCardModal = () => {
		dispatch(open({type: ADD_CARD}))
	}

	const hasNoCards = cards.length === 0

	return (
		<DashboardSection
			title='My cards'
			emptyChildrenText='you have no cards yet'
			height='sm'
			option={<Button buttonStyle='accent' type='general' icon='add' onClick={addCardModal} text='New card'></Button>}>
			{!hasNoCards ? <CardsContainer cards={cards} /> : null}
		</DashboardSection>
	)
}

export default CardsScene