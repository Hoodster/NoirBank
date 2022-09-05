import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'
import BillingHistoryContainer from './billing-history-container'

function BillingHistoryModal() {
	const [logs, setLogs] = useState()
	const dispatch = useDispatch()
    
	useEffect(() => {
		setLogs(['a','b'])
		console.log(logs)
	},[])

	const primaryAction = {
		action: () => dispatch(close()),
		text: 'Ok'
	}
    
	return <ModalBase title='Billing history' primaryAction={primaryAction}>
		<BillingHistoryContainer />
	</ModalBase>
}

export default BillingHistoryModal