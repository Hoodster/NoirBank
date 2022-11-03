import React from 'react'
import Button from '../inputs/button/button'
import './action-buttons.scss'

function ActionButtons(props) {
	const additionalClass = props.className ? ' ' + props.className : ''

	let primaryButtonProps = {
		icon: ''
	}

	let secondaryButtonProps = {
		icon: ''
	}

	if (props.primaryActionButton?.icon) {
		primaryButtonProps.icon = props.primaryActionButton.icon
	}

	const addSecondaryButton = () => {
		if (props.secondaryActionButton) {
			if (props.secondaryActionButton.icon) {
				secondaryButtonProps.icon = props.secondaryActionButton.icon
			}
			return (<Button type='mod' buttonStyle='primary' text={props.secondaryActionButton.text} onClick={props.secondaryActionButton.action} {...secondaryButtonProps} />)
		}
	}

	return (
		<div className={'action-buttons' + additionalClass} position={props.position ? props.position : 'center'}>
			{
				addSecondaryButton()
			}
			<Button type='mod' buttonStyle='primary' text={props.primaryActionButton?.text} onClick={props.primaryActionButton?.action} {...primaryButtonProps} />
		</div>
	)
}
export default ActionButtons