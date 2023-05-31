import React from 'react'
import Button from '../inputs/button/button'
import styles from './action-buttons.module.scss'
import clsx from 'clsx'

function ActionButtons(props) {
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
		<div className={clsx(styles['action-buttons'], styles[props.className], styles[props.position ?? 'center'])}>
			{
				addSecondaryButton()
			}
			<Button type='mod' buttonStyle='primary' text={props.primaryActionButton?.text} onClick={props.primaryActionButton?.action} {...primaryButtonProps} />
		</div>
	)
}
export default ActionButtons