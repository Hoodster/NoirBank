/* eslint-disable no-unused-vars */
import React from 'react'
import styles from './dashboard-section.module.scss'
import clsx from 'clsx'

function DashboardSection(props) {
	const emptyStyle = styles['container-empty']
	const heightStyle = styles[props.height]
	return (
		<div className={styles['nb-dash-section']}>
			<div className={styles.titleSection}>
				<span className={styles.title}>{props.title}</span>
				{props.option ?? null}
			</div>
			<div className={clsx(styles.container, emptyStyle , heightStyle)}>
				{props.children
					? props.children
					: <span style={{ 'margin': '65px 0' }} className={styles.emptyMessage}>{props.emptyChildrenText}</span>}
			</div>
		</div>
	)
}

export default DashboardSection