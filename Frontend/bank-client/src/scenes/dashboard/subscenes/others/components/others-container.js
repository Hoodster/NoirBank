import React from 'react'
import Button from '../../../../../components/inputs/button/button'
import './others-container.scss'

function OthersContainer() {
	return <div className="othersContainer">
		<Button type="main" style='primary' text="Billing history"></Button>
		<Button type='main' style='primary' text="Make a transfer"></Button>
	</div>
}

export default OthersContainer