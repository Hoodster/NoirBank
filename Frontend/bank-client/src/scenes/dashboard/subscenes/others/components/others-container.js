import React from 'react'
import { useDispatch } from 'react-redux'
import Button from '../../../../../components/inputs/button/button'
import { MAKE_TRANSFER, VIEW_BILLING_HISTORY, VIEW_SIGNIN_LOGS } from '../../../../../modals/constants'
import { open } from '../../../../../redux/reducers/modal-reducer'
import './others-container.scss'

function OthersContainer() {
	const dispatch = useDispatch()

	const openBillingHistory = () => {
		dispatch(open(VIEW_BILLING_HISTORY))
	}

	const openTransferModal = () => {
		dispatch(open(MAKE_TRANSFER))
	}

	const openSessionLogs = () => {
		dispatch(open(VIEW_SIGNIN_LOGS))
	}

		
	return (<div className="othersContainer">
		<Button type="main" style='primary' onClick={openBillingHistory} text="Billing history"></Button>
		<Button type='main' style='primary' onClick={openTransferModal} text="Make a transfer"></Button>
		<Button type="main" style='primary' onClick={openSessionLogs} text="Sign in log"></Button>
	</div>)
}

export default OthersContainer