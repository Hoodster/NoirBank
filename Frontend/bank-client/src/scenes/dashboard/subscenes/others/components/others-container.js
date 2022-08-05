import React from 'react'
import Button from '../../../../../components/inputs/button/button'
import './others-container.scss'

function OthersContainer() {
	return <div className="othersContainer">
		<Button type="main" text="Payment history"></Button>
		<Button type='main' text="Make a transfer"></Button>
	</div>
}

export default OthersContainer