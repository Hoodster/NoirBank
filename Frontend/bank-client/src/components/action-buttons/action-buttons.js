import React from 'react'
import Button from '../inputs/button/button'
import './action-buttons.scss'

function ActionButtons(props) {
	const additionalClass = props.className ? ' ' + props.className : ''
	const primaryActionButton = props.primaryActionButton
		? props.primaryActionButton
		: {
			text: 'Ok',
			action: () => console.log('ok')
		}

	let primaryButtonProps = {
		icon: ''
	}

	let secondaryButtonProps = {
		icon: ''
	}

	if (primaryActionButton.icon) {
		console.log(primaryActionButton)
		primaryButtonProps.icon = primaryActionButton.icon
	}

	const addSecondaryButton = () => {
		if (props.secondaryActionButton) {
			if (props.secondaryActionButton.icon) {
				secondaryButtonProps.icon = props.secondaryActionButton.icon
			}
			return (<Button type='main' style='primary' text={props.secondaryActionButton.text} onClick={props.secondaryActionButton.action} {...secondaryButtonProps} />)
		}
	}

	return (
		<div className={'action-buttons' + additionalClass} position={props.position ? props.position : 'center'}>
			{
				addSecondaryButton()
			}
			<Button type='main' style='primary' text={primaryActionButton.text} onClick={primaryActionButton.action} {...primaryButtonProps} />
		</div>
	)
}
export default ActionButtons