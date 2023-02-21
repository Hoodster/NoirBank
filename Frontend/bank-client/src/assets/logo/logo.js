import React from 'react'
import styles from './logo.module.scss'
import clsx from 'clsx'

function Logo(props) {
	return (
		<div className={clsx(styles.logo, styles.className)}>
			<span className={clsx(styles.noir, styles[props.size])}>Noir</span>
			<span className={clsx(styles.bank, styles[props.size])}>Bank</span>
		</div>
	)
}

export default Logo