# fongkong

#### 项目介绍
该项目为策略风控，简易的配置方式和灵活的拦截形式
多应用 多事件 多策略
策略组合方式为两种，首次命中和权重模式


#### 软件架构

策略引擎
.netcore + nginx + redis

策略配置平台
.netcore + mongodb


#### 安装教程

暂无

#### 使用说明

##APP管理
    支持多应用配置
##事件管理
    应用中，可以多事件，用于不同应用场景，如登录、注册、下单、抢红包等
##策略管理
    具体的规定事件中限制条件，如同ip在10分钟内不能操作100次订单；手机号在10分钟内下单不能超过20个

事件策略存储格式：
```
{
    "AppName" : "TestPRO",
    "AppId" : "xxx-xxx-xxx",
    "Events" : [ 
        {
            "EventName" : "用户登录",
            "EventCode" : "login",
            "EventType" : "FirstHit-首次命中",
            "PolicyList" : [ 
                {
                    "field" : [ 
                        "ip"
                    ],
                    "maxSize" : 10,
                    "timeSlice" : 30,
                    "policyType" : "single-单一策略"
                }
                {
                    "field" : [ 
                        "mobile", 
                        "ip"
                    ],
                    "maxSize" : 20,
                    "timeSlice" : 120,
                    "policyType" : "group-组合策略"
                }
            ]
        }
    ]
}
```


风控请求接口
xxx.com/secapi
传入参数：
```
{
    "appid": "xxx-xxx-xxx",
    "eventCode": "login",
    "data": {
        "mobile": "18605110000",
        "ip": "192.168.1.1"
    }
}
```
返回参数
```
{
    "uuid": "xxxx-3bef-4382-a040-xxxx",
    "status": "SUCCESS",
    "result": {
        "RiskLevel": "ACCEPT",
        "HitPolicyCode": "",
        "HitRules": ""
    }
}
```


