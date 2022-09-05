import React from 'react'
import './card.scss'

function Card(props) {
	return <div className={`nb-card ${props.cardStyle}`}>
		<span>{props.cardNo}</span>
		<div className='nb-card-row-last'>
			<span>{props.expiration}</span>
			<span className='nb-cardType'>{props.type}</span>
		</div>
		<span> </span>
	</div>
}

export default Card