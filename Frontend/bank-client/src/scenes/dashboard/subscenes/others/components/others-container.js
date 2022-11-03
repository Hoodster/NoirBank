import React from 'react'
import { useDispatch } from 'react-redux'
import Button from '../../../../../components/inputs/button/button'
import { MAKE_TRANSFER, VIEW_BILLING_HISTORY, VIEW_AUTHORIZATION_LOGS } from '../../../../../modals/constants'
import { open } from '../../../../../redux/reducers/modal-reducer'
import './others-container.scss'

function OthersContainer() {
	const dispatch = useDispatch()

	const openBillingHistory = () => {
		dispatch(open({type: VIEW_BILLING_HISTORY}))
	}

	const openTransferModal = () => {
		dispatch(open({type: MAKE_TRANSFER}))
	}

	const openSessionLogs = () => {
		dispatch(open({type: VIEW_AUTHORIZATION_LOGS}))
	}


	return (<div className="othersContainer">
		<Button type="main" buttonStyle='primary' onClick={openBillingHistory} text="Billing history"></Button>
		<Button type='main' buttonStyle='primary' onClick={openTransferModal} text="Make transfer"></Button>
		<Button type="main" buttonStyle='primary' onClick={openSessionLogs} text="Authorization logs"></Button>
	</div>)
}

export default OthersContainer