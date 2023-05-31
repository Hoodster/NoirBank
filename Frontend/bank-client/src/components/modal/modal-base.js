import React from 'react'
import { useDispatch } from 'react-redux'
import { close } from '../../redux/reducers/modal-reducer'
import ActionButtons from '../action-buttons/action-buttons'
import styles from './modal-base.module.scss'
import clsx from 'clsx'

function ModalBase(props) {
	const dispatch = useDispatch()

	const closeModal = () => {
		dispatch(close())
	}

	return (
		<div className={styles['modal-container']}>
			<div className={styles['modal-background']} onClick={closeModal} />
			<div className={styles.modal}>
				<h4 className={styles['modal-title']}>{props.title}</h4>
				<div className={clsx(styles.content, props.contentPosition ?? 'left')}>
					{props.children}
				</div>
				<ActionButtons
					primaryActionButton={props.primaryAction}
					secondaryActionButton={props.secondaryAction}
					position='right' />
			</div>
		</div>
	)
}

export default ModalBase