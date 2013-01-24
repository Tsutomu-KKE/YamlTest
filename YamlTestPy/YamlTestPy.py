#!/usr/bin/python
"""
YAML Sample
http://pyyaml.org/wiki/PyYAML
"""
import os, sys, yaml

class Company(yaml.YAMLObject):
	yaml_tag = '!Company'
class Group(yaml.YAMLObject):
	yaml_tag = '!Group'
class Employee(yaml.YAMLObject):
	yaml_tag = '!Employee'
class YamlTestPy:
	@staticmethod
	def SerializeSample(fnam):
		co = Company()
		co.Name = 'Googol'
		co.Employees = [Employee()]
		co.Employees[0].Name = 'A'
		co.Employees[0].Age = 30
		co.Groups = [Group()]
		co.Groups[0].Name = 'G'
		co.Groups[0].Employees = [co.Employees[0]]
		f = open(fnam, 'w')
		yaml.dump(co, f)
		f.close()
	@staticmethod
	def DeserializeSample(fnam):
		f = open(fnam)
		co = yaml.load(f)
		f.close()
		co.Employees[0].Age = 24
		print co.Groups[0].Employees[0].Age
	@staticmethod
	def Main():
		#YamlTestPy.SerializeSample('../test.yml')
		YamlTestPy.DeserializeSample('../test.yml')
		print 'Press Enter'
		sys.stdin.readline()

if __name__ == '__main__': YamlTestPy.Main()