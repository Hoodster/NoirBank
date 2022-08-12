/* eslint-disable react/jsx-key */
import React from 'react'
import Card from '../../../../../../components/card/card'
import './cards-container.scss'
import Swipeable from '../../../../../../components/swipeable/swipeable'

function CardsContainer() {
	return (
		<div className='cards-container'>
			<Swipeable
				space={25}
				data={[
					<Card cardStyle="card1" cardNo="1001000000001001" expiration="10/22" type='Credit'/>,
					<Card cardStyle="card2" cardNo="0000000000000000" expiration="10/22" type='Debit'/>,
					<Card cardStyle="card3" cardNo="0000000000000000" expiration="10/22" type='Debit'/>,
					<Card cardStyle="card4" cardNo="0000000000000000" expiration="10/22" type='Credit'/>,
					<Card cardStyle="card1" cardNo="1001000000001001" expiration="10/22" type='Credit'/>,
					<Card cardStyle="card2" cardNo="0000000000000000" expiration="10/22" type='Debit'/>,
					<Card cardStyle="card3" cardNo="0000000000000000" expiration="10/22" type='Debit'/>,
					<Card cardStyle="card4" cardNo="0000000000000000" expiration="10/22" type='Credit'/>,
					<Card cardStyle="card1" cardNo="1001000000001001" expiration="10/22" type='Credit'/>,
					<Card cardStyle="card2" cardNo="0000000000000000" expiration="10/22" type='Debit'/>,
					<Card cardStyle="card3" cardNo="0000000000000000" expiration="10/22" type='Debit'/>,
					<Card cardStyle="card4" cardNo="0000000000000000" expiration="10/22" type='Credit'/>,
				]} />
		</div>
	)
}

export default CardsContainer