import React, { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { get } from '../../helpers/api'
import { customerAPI } from '../../helpers/endpoints'
import { close, setModalData } from '../../redux/reducers/modal-reducer'
import BillingHistoryContainer from './billing-history-container'

function BillingHistoryModal() {
	const dispatch = useDispatch()
    
	useEffect(() => {
		get(`${customerAPI}/billing`).then((response) => {
			dispatch(setModalData({
				accounts: response.data.data
			}))
		})
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