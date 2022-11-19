import React from 'react'
import styles from './card.module.scss'
import clsx from 'clsx'

function Card(props) {
	return <div className={clsx(styles['nb-card'], styles[props.cardStyle], styles[props.cardSize])}>
		<span>{props.cardNo}</span>
		<div className={styles['nb-card-row-last']}>
			<span>{props.expiration}</span>
			<span className={styles['nb-cardType']}>{props.type}</span>
		</div>
		<span> </span>
	</div>
}

export default Card