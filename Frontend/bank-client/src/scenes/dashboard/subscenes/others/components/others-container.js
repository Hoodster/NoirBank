import React from 'react'
import { useDispatch } from 'react-redux'
import Button from '../../../../../components/inputs/button/button'
import { MAKE_TRANSFER } from '../../../../../modals/constants'
import { open } from '../../../../../redux/reducers/modal-reducer'
import './others-container.scss'

function OthersContainer() {
	const dispatch = useDispatch()

	const openTransferModal = () => {
		dispatch(open(MAKE_TRANSFER))
	}

	return (<div className="othersContainer">
		<Button type="main" style='primary' text="Billing history"></Button>
		<Button type='main' style='primary' onClick={openTransferModal} text="Make a transfer"></Button>
	</div>)
}

export default OthersContainer