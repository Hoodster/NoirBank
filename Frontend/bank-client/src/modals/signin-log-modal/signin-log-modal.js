import React, { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { get } from '../../helpers/api'
import { userAPI } from '../../helpers/endpoints'
import { close, setModalData } from '../../redux/reducers/modal-reducer'
import SignInLogContainer from './signin-log-container'

function SignInLogModal() {
	const dispatch = useDispatch()

	useEffect(() => {
		get(`${userAPI}/sessionlogs`).then((response) => {
			dispatch(setModalData({
				logs: response.data.data
			}))
		})
	},[])

	const primaryAction = {
		action: () => dispatch(close()),
		text: 'Ok'
	}
    
	return <ModalBase title='Authorization logs' primaryAction={primaryAction}>
		<SignInLogContainer />
	</ModalBase>
}

export default SignInLogModal