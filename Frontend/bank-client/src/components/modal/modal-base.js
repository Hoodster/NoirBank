import React from 'react'
import ActionButtons from '../action-buttons/action-buttons'
import './modal-base.scss'

function ModalBase(props) {
	return (
		<div className='modal-container'>
			<div className='modal-background' />
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