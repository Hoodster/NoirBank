import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'
import SignInLogContainer from './signin-log-container'

function SignInLogModal() {
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
    
	return <ModalBase title='Signing in logs' primaryAction={primaryAction}>
		<SignInLogContainer />
	</ModalBase>
}

export default SignInLogModal