import React from 'react'
import styles from './radio.module.scss'

function Radio(props) {
	const setRadioChecked = () => {
		const radioButton = document.getElementById(props.id)
		radioButton.checked = true
	}

	return (
		<div className={styles['nb-radio']} onClick={setRadioChecked}>
			<input id={props.id} name={props.name} type={'radio'} value={props.value} defaultChecked={props.default} />
			<label htmlFor={props.id}>{props.text}</label>
		</div>
	)
}

export default Radio