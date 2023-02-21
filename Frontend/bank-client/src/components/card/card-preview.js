import React from 'react'
import Card from './card'

function CardPreview(props) {
	return (
		<Card expiration='' type='' cardStyle={props.cardStyle} cardSize={props.cardSize} isEmpty />
	)
}

export default CardPreview