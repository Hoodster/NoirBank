import React from 'react'
import { useDispatch } from 'react-redux'
import { close } from '../../redux/reducers/modal-reducer'
import ActionButtons from '../action-buttons/action-buttons'
import './modal-base.scss'

function ModalBase(props) {
	const dispatch = useDispatch()

	const closeModal = () => {
		dispatch(close())
	}

	return (
		<div className='modal-container'>
			<div className='modal-background' onClick={closeModal} />
			<div className='modal'>
				<h3 className='modal-title'>{props.title}</h3>
				<div className='content' position={props.contentPosition ? props.contentPosition : 'left'}>
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