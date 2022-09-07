/* eslint-disable react/jsx-key */
import React from 'react'
import Card from '../../../../../../components/card/card'
import './cards-container.scss'
import Swipeable from '../../../../../../components/swipeable/swipeable'

function CardsContainer(props) {
	return (
		<div className='cards-container'>
			<Swipeable
				space={25}
				data={
					props.cards.map(card => 
						<Card 
							cardStyle={card.cover} 
							cardNo={card.hiddenNumber} 
							expiration={`${card.expirationMonth}/${card.expirationYear}`} 
							type={card.type}/>
					)
				} />
		</div>
	)
}

export default CardsContainer